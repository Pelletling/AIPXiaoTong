using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class UserPasswordAttribute: ValidationAttribute
    {
        UserCM user;
        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}不能为空", name);
        }

        public UserPasswordAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            user = validationContext.ObjectInstance as UserCM;

            if (user.ID == 0 && string.IsNullOrWhiteSpace(user.Password))
            {
                return new ValidationResult("密码不能为空");
            }

            return ValidationResult.Success;
        }
    }
}
