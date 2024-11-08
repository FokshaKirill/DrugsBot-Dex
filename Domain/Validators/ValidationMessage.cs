namespace Domain.Validators;

public static class ValidationMessage
{
    public static string NotNull = "{PropertyName} не может быть NULL";
    public static string NotEmpty = "{PropertyName} не может быть пустым";
    public static string WrongLength = "{PropertyName} должен быть от {min} до {max} символов";
    public static string WrongMatches = "{PropertyName} не соответствует требованиям именования";
    public static string NotGreaterThanNum = "{PropertyName} должен быть больше чем {}";
    public static string WrongPrecisionScale = "{PropertyName} должен содержать {} цифр до запятой и {} - после, игнорируя конечные нули";
}