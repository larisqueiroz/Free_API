using System.ComponentModel.DataAnnotations;

namespace Free_API.Enums;

public enum UserType
{
    [Display(Name = "USER")]
    USER,
    [Display(Name = "OPERATOR")]
    OPERATOR,
    [Display(Name = "ADMIN")]
    ADMIN
}