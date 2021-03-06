﻿using System;
using System.IO;
using System.Net;
using AlgBuild.BuildSettings;
using AlgBuild.BuildTypes;
using AlgBuild.Engine;
using AlgBuild.Executors.Item;

namespace AlgBuild.Executors
{
    public class PublishSettingItemExecutor: SettingItemExecutor<PublishSettingItem>
    {
        public PublishSettingItemExecutor(PublishSettingItem settingItem)
            : base(settingItem)
        {
        }

        public void Execute(string rootPath, PublishFtpSetting ftpSetting, VersionType versionType, Lang lang)
        {
            if (!CanExecute(versionType, lang))
                return; 
            
            var sourceFileName = string.Format(Constants.InstallNamePattern, versionType, lang);
            var sourceFilePath = Path.Combine(rootPath, Constants.InstallsFolderName, sourceFileName);

            var destinationFilePath = Path.Combine(rootPath, Constants.PublishFolderName, SettingItem.TargetName);

            File.Copy(sourceFilePath, destinationFilePath, true);

            var destinationUri = UriCombine(ftpSetting.FtpUrl,
                                            SettingItem.TargetPath, SettingItem.TargetName);
            UploadFile(destinationFilePath, destinationUri, ftpSetting);
        }

        public static void UploadFile(string sourceFilePath, Uri destinationFileUrl, PublishFtpSetting ftpSetting)
        {
            var ftpClient = (FtpWebRequest)WebRequest.Create(destinationFileUrl);
            ftpClient.Credentials = new NetworkCredential(ftpSetting.FtpUsername, ftpSetting.FtpPassword);
            ftpClient.Method = WebRequestMethods.Ftp.UploadFile;
            ftpClient.UseBinary = true;
            ftpClient.KeepAlive = true;

            var fi = new FileInfo(sourceFilePath);
            ftpClient.ContentLength = fi.Length;

            var buffer = new byte[4097];
            var totalBytes = (int)fi.Length;
            FileStream fs = fi.OpenRead();
            Stream rs = ftpClient.GetRequestStream();
            while (totalBytes > 0)
            {
                int bytes = fs.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                totalBytes = totalBytes - bytes;
            }
            fs.Close();
            rs.Close();

            var uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
            var result = uploadResponse.StatusDescription;
            uploadResponse.Close();
        }

        public static Uri UriCombine(string path1, string path2, string path3 = "", string path4 = "")
        {
            string path = Path.Combine(path1, path2.TrimStart('\\', '/'), path3.TrimStart('\\', '/'), path4.TrimStart('\\', '/'));
            string url = path.Replace('\\', '/');
            return new Uri(url);
        }
    }
}
