﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Dto
{
    public record RegisterRequestDto(string? Email, string? Password, string? PersonName, GenderOptions GenderOptions);
}
