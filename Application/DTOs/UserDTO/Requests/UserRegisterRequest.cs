﻿namespace Application.DTOs.UserDTO.Requests;

public class UserRegisterRequest
{
    public string? FullName { get; set; }

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

}