using System.ComponentModel.DataAnnotations;
using Free_API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Free_API.Models.DAO;

public class User
{
    public string Name { get; set; } = String.Empty;
    [Key]
    public string Email { get; set; } = String.Empty;
    public UserType UserType { get; set; }
    public byte[] Hash { get; set; }
    public byte[] Salt  { get; set; }
}