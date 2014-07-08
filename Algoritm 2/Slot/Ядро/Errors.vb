Module Errors
    Function notFile(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя файла
        Return trans("Файл * не существует").Replace("*", str)
    End Function
    Function notRegistry(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя файла
        Return trans("Ключ или папка * не существует в реестре").Replace("*", str)
    End Function
    Function InvalidPathChars(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя файла
        Return trans("Путь * содержит недопустимые символы").Replace("*", str)
    End Function
    Function InvalidFormatRegistry(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Значение ** имеет недопустимый формат для ключа реестра *.").Replace("**", str1).Replace("*", str2)
    End Function
    Function FileNotCreate(ByVal str1 As String) As String
        Return trans("Невозможно обратиться к файлу. Проверьте правильность написания пути. Ошибка:") & " " & str1
    End Function
    Function ProjNotFound(ByVal str1 As String) As String
        Return trans("Проект ""*"" не найден").Replace("*", str1)
    End Function
    Function DivideByZero(ByVal str1 As String) As String
        Return trans("Попытка деления на 0 в действии ""*"". По правилам арифметики это запрещено!").Replace("*", str1)
    End Function
    Function notCollection(ByVal nameColl As String, ByVal val As String, ByVal coll As String()) As String
        val = """" & val & """"
        val = nameColl & trans(" * не существует. Проверьте правильность написания. Доступны следующие варианты:").Replace("*", val)
        Dim i As Integer : val &= " "
        For i = 0 To coll.Length - 1
            val &= """" & coll(i) & """"
            If i < coll.Length - 1 Then val &= ", "
        Next
        val &= "." & vbCrLf & vbCrLf & trans("Подробнее в пункте меню") & " """ & trans("Вспомогательные слова") & """."
        Return val
    End Function
    Function notCollectionCols(ByVal nameColl As String, ByVal val As String, ByVal coll As String()) As String
        val = notCollection(nameColl, val, coll)
        val &= vbCrLf & vbCrLf & trans("Также цвета можно задать перечисляя через точку с запятой интенсивности красного, зеленого, синего. Интенсивности задаются в диапазоне от 0 до 255.")
        Return val
    End Function
    Function notDaOrNet(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильную привязку
        Return trans("Данное свойство может принимать только значения ""Да"", либо ""Нет"". А вы ввели *.").Replace("*", str)
    End Function
    Function notInvers(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильную привязку
        Return trans("Инверсия может принимать только значения ""Да"", ""Нет"", ""1"", ""0"". А вы ввели *.").Replace("*", str)
    End Function
    Function notTableAccess() As String
        Return trans("Для того чтобы сохранить файл Access, нужно его сначала открыть командой ""Открыть Access"".")
    End Function
    Function notChar(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильную привязку
        Return trans("Строка * не является символом. Свойству требуется только символ.").Replace("*", str)
    End Function
    Function noArguments(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильную привязку
        Return trans("Передано недостаточное количество информация для свойства *. Вы указали не все данные что нужны ему.").Replace("*", str)
    End Function
    Function noItems(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("В свойстве ** был указан слишком большой номер записи *. В списке меньше, чем * записей.").Replace("**", str1).Replace("*", str2)
    End Function
    Function noRows(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("В свойстве ** был указан слишком большой номер строки *. В таблице меньше, чем * строк.").Replace("**", str1).Replace("*", str2)
    End Function
    Function noColumns(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("В свойстве ** был указан слишком большой номер столбца *. В таблице меньше, чем * столбцов.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notUnderstand(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Не понятно, что имеется ввиду выражением *.").Replace("*", str)
    End Function
    Function notRowCount(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("В свойстве * нужно было указать строку из таблицы. А в таблице меньше чем ** строк.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notColumnCount(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("В свойстве * нужно было указать столбец из таблицы. А в таблице меньше чем ** столбцов.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notInt(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("** не является целым числом, либо слишком велико. А свойство * может принимать только целые числовые значения.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notLength(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        str2 = """" & str2 & """"
        Return trans("В свойстве *** невозможно добраться до символа номер *, т.к. строка ** имеет длинну ****.").Replace("****", str2.Length - 2).Replace("***", str1).Replace("**", str2).Replace("*", str3)
    End Function
    Function notDouble(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("** не является числом, либо слишком велико. А функция * работает только с числами.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notLessEqZero(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("** не является положительным числом. А свойство * может принимать только положительные числовые значения.").Replace("**", str1).Replace("*", str2)
    End Function
    Function notDateLimit(ByVal str1 As String, ByVal str2 As String, ByVal str3 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        If str3 <> "" Then str3 = """" & str3 & """"
        Return trans("Дата *** должна быть в диапазоне от ** до *").Replace("***", str1).Replace("**", str2).Replace("*", str3)
    End Function
    Function notLessZero(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("** отрицательное число. А свойство * не может принимать отрицательные числа.").Replace("**", str1).Replace("*", str2)
    End Function
    Function ExistUniqName(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("У вас два объекта с одинаковым именем ** и номером *. Чтобы запустить программу сначала сделайте имена объектов разными, либо измените их свойства Номер, либо удалите ненужный объект.").Replace("**", str1).Replace("*", str2)
    End Function
    Function ParseIfError(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Неожиданное действие **. Ожидалось действие следующего типа(ов): *. Другими словами, вы ошиблись в структуре условий. Исправьте их, чтобы запустить проект.").Replace("**", str1).Replace("*", str2)
    End Function
    Function NotReturn(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Строка * не возвращает никакого значения.").Replace("*", str)
    End Function
    Function notIcon(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Файл * не является иконкой.").Replace("*", str)
    End Function
    Function FileNoAccess(ByVal str As String) As String
        MsgBox(trans("Невозможно получить доступ к файлу, укажите другой файл. Произошла ошибка:") & vbCrLf & str, MsgBoxStyle.Exclamation)
    End Function
    Function FilePathNotExist(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Файл или папка * не существует, проверьте правильность пути").Replace("*", str)
    End Function
    Function FileNotExist(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Файл * не существует, проверьте правильность пути").Replace("*", str)
    End Function
    Function PathNotExist(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Папка * не существует, проверьте правильность пути").Replace("*", str)
    End Function
    Function isReadOnly(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Нельзя изменять свойство *, оно доступно только для чтения.").Replace("*", str)
    End Function
    Function notDate(ByVal str As String) As String
        Dim val As String
        str = """" & str & """"
        val = trans("Значение * не может перевестись в дату и время. Допустимы следующие варианты:").Replace("*", str)
        Dim i As Integer : val &= " "
        For i = 0 To Now.GetDateTimeFormats.Length - 1
            val &= """" & Now.GetDateTimeFormats()(i) & """"
            If i < Now.GetDateTimeFormats.Length - 1 Then val &= ", "
        Next
        Return val
    End Function
    Function notTime(ByVal str As String) As String
        str = """" & str & """"
        Return trans("Значение * не может перевестись во временной интервал. Допустимый формат ЧЧ:ММ:СС.мм").Replace("*", str)
    End Function
    Function CreateMassive(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return transInfc("Объект с именем *уже существует, хотите создать массив объектов?").Replace("*", str)
    End Function
    Function NameExist(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return transInfc("Объект с именем *уже существует, задайте другое имя").Replace("*", str)
    End Function
    Function FontNotSupport(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Ошибка шрифта *. Возможно шрифт не сочетается с стилем (жирность, курсив, подчеркивание и т.д.), задайте другие параметры стиля и попробуйте еще раз выбрать данный шрифт:").Replace("*", str)
    End Function
    Function InvalidIndex(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильный индекс
        Return trans("Объект с индексом *уже существует, задайте другой индекс").Replace("*", str)
    End Function
    Function AlreadyHaveElse() As String
        Return trans("Раздел ""В остальных случаях"" уже присутствует в данном условии. В условии может быть только один такой раздел")
    End Function
    Function NameInvalid(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return trans("Имя *задано неверно. Объект не может иметь такое имя.").Replace("*", str)
    End Function
    Function NameInvalidLength(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return trans("Имя объекта не может отсутствовать").Replace("*", str)
    End Function
    Function NameInvalidSimvols(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return transInfc("Имя *содержит недопустимые символы. В написании имени объектов можно использовать только буквы, цифры и пробелы").Replace("*", str)
    End Function
    Function NameInvalidProbels(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return trans("Имя объекта не может начинаться с побела").Replace("*", str)
    End Function
    Function NameInvalidDigit(ByVal str As String) As String
        If str <> "" Then str = """" & str & """ " ' Если в str передали неправильное имя
        Return trans("Имя объекта не может начинаться с цифры").Replace("*", str)
    End Function
    Function NameInvalidFuns(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя
        Return transInfc("В программе существует функция c именем *, задайте другое имя.").Replace("*", str)
    End Function
    Function NameInvalidHW(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя
        Return transInfc("В программе существует вспомогательное слово *, задайте другое имя.").Replace("*", str)
    End Function
    Function NotSupportIncludeObj() As String
        Return transInfc("Данный объект можно разместить только на объектах такого же типа, как он сам.")
    End Function
    Function InvalidPropObj() As String
        Return trans("Не известно, что означает одинарная кавычка")
    End Function
    Function InvalidKovich() As String
        Return trans("Не верно задано свойство или метод объекта")
    End Function
    Function ObjIsNothing() As String
        Return trans("Такой объект не существует")
    End Function
    Function ObjIsNothing(ByVal name As String) As String
        If name <> "" Then name = """" & name & """"
        Return trans("Объект * не существует").Replace("*", name)
    End Function
    Function MnogoRavno() As String
        Return trans("Не известно, что означают несколько знаков равно( ""="" ). Используйте скобки, чтобы указать программе как интерпритировать эти знаки.")
    End Function
    Function NotEndIF(ByVal str As String) As String
        If str <> "" Then str = """" & str & """"
        Return trans("Не найдено завершение условия *. Условия должны заканчиваться действием ""Конец условия"".").Replace("*", str)
    End Function
    Function notPropertyMethod(ByVal str As String) As String
        If str <> "" Then str = """" & str & """" ' Если в str передали неправильное имя
        Return trans("У данного объекта не существует свойства или метода *. Проверьте правильность его написания.").Replace("*", str)
    End Function
    Function notMainClass(ByVal str As String) As String
        Return trans("Отсутствует обязательный класс MainClass, с которого начинает выполняться код. Ошибочный код:*").Replace("*", vbCrLf & str)
    End Function
    Function notRunNode(ByVal str As String) As String
        str = """" & str & """"
        Return trans("Невозможно выполнить строку *. Выполняться могут только Действия, Условия и Циклы.").Replace("*", str)
    End Function
    Function InvalidContextMenu(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Контектсного меню с именем **, заданного для объекта * не существует").Replace("**", str1).Replace("*", str2)
    End Function
    Function InvalidWebBrowser(ByVal str1 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        Return trans("Браузера с именем * не существует").Replace("*", str1)
    End Function
    Function MoreRecurs(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Вызов функцией ** самой себя, повторился более * раз. Возможно рекурсия бесконечная. Дальнейшая работа может быть крайне нестабильна. Вы хотите продолжить выполнение данной рекурсии?").Replace("**", str1).Replace("*", str2)
    End Function
    Function MoreCycles(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Цикл ** повторился более, повторился более * раз. Возможно цикл бесконечный. Вы хотите продолжить выполнение данного цикла?").Replace("**", str1).Replace("*", str2)
    End Function
    Sub MessangeCritic(ByVal str As String)
        MsgBox(trans("Произошла непредвиденная ошибка") & ": " & str & GetAnswersMessage(), MsgBoxStyle.Critical)
    End Sub
    Sub MessangeInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information)
    End Sub
    Sub MessangeExclamen(ByVal str As String)
        MsgBox(str & GetAnswersMessage(), MsgBoxStyle.Exclamation)
    End Sub
    Function InvalidKeys(ByVal str1 As String, ByVal str2 As String) As String
        If str1 <> "" Then str1 = """" & str1 & """"
        If str2 <> "" Then str2 = """" & str2 & """"
        Return trans("Невозможно назначить комбинацию клавиш **, объекту *").Replace("**", str1).Replace("*", str2)
    End Function
    Function InvalidUrl(ByVal str As String) As String
        str = """" & str & """"
        Return trans("Невозможно перейти по ссылке *. Ссылка имеет не верный формат.").Replace("*", str)
    End Function
    Function GetAnswersMessage() As String
        Return vbCrLf & vbCrLf & trans("Если в сложившейся ситуации вам необходима помощь, то поищите ответ или задайте свой вопрос на") + " " + SiteAlg + answersAlgPath
    End Function
End Module
