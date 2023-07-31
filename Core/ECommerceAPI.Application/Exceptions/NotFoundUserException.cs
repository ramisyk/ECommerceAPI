﻿namespace ECommerceAPI.Application.Exceptions;

public class NotFoundUserException : Exception
{
    public NotFoundUserException() : base("Wrong user name or password...")
    {
    }

    public NotFoundUserException(string? message) : base(message)
    {
    }

    public NotFoundUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}