using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    [AuthorDOBMustComeBeforeDOD(ErrorMessage ="Date of Death must be after a Birth")]
    public class AuthorForCreationWithDateOfDeathDto : AuthorForCreationDto
    {
        public DateTimeOffset? DateOfDeath { get; set; }
        public DateTimeOffset? DateOfReborn { get; set; }
    }
}
