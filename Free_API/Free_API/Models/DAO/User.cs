﻿namespace Free_API.Models.DAO;

public class User
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public byte[] Hash { get; set; }
    public byte[] Salt  { get; set; }
}