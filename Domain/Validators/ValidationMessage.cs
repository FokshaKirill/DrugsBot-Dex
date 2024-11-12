namespace Domain.Validators;

public static class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть NULL";
    public static string NotEmpty = "{PropertyName} не может быть пустым";
    public static string WrongLengthRange = "{PropertyName} должен быть от {min} до {max} символов";
    public static string WrongLength = "{PropertyName} должен состоять только из {0} символов";
    public static string WrongMatches = "{PropertyName} не соответствует требованиям именования";
    public static string WrongPrecisionScale = "{PropertyName} должен содержать {} цифр до запятой и {} - после, игнорируя конечные нули"; 
    public static string WrongCountryCode = "{PropertyName} имеет некорректный код страны. Он должен состоять из двух больших латинских букв"; 
    public static string WrongPostalCode = "{PropertyName} должен быть числовым и состоять из 5-6 цифр";
    public static string LessThanNumError = "{PropertyName} должен быть больше чем {min}";
    public static string GreaterThanNumError = "{PropertyName} должен быть меньше чем {max}";
    public static string NegativeNumOrZeroError = "{PropertyName} не может быть отрицательным значением или нулём";
    public static string NegativeNumError = "{PropertyName} не может быть отрицательным значением";
    public static string SpecialSymbolsError = "{PropertyName} не должен содержать специальных символов";
}