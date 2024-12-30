using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Dto
{
    public record LoginRequestDto(string? Email, string? password);
}
