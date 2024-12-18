﻿namespace Domain.Validation;

public static class RegexPatterns
{
    public static string OnlyLettersAndSpaces = @"^[A-ZА-Я\s]+$";
    public static string OnlyLettersSpacesDashes = @"^[A-ZА-Яa-zа-я\s\-]+$";
    public static string OnlyLatinLettersSpacesDashes = @"^[A-Za-z\s\-]+$";
    public static string OnlyBigLatinLetters = "^[A-Z]+$";
    public static string OnlyLetters = "^[A-ZА-Яa-zа-я]+$";
    public static string OnlyNums = @"^[\d]$";
    public static string NoSpecialSymbols = "^[A-ZА-Яa-zа-я0-9]+$";
    public static string EmailPattern = @"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$";
}