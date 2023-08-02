﻿using ECommerceAPI.Application.Dtos;

namespace ECommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;

public class LoginUserCommandResponse
{

}
public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
{
    public Token Token { get; set; }
}
public class LoginUserErrorCommandResponse : LoginUserCommandResponse
{
    public string Message { get; set; }
}