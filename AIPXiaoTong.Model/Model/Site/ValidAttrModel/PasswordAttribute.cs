﻿using AIPXiaoTong.Model.Site;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class PasswordAttribute : ValidationAttribute
    {
        EmployeeCM employee;
        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}不能为空", name);
        }

        public PasswordAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            employee = validationContext.ObjectInstance as EmployeeCM;

            if (employee.ID == 0 && string.IsNullOrWhiteSpace(employee.Password))
            {
                return new ValidationResult("密码不能为空");
            }

            return ValidationResult.Success;
        }
    }
}
