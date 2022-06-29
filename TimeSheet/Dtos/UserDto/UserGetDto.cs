using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Entities;

namespace TimeSheet.Dtos.UserDto
{
    public class UserGetDto
    {
        public string uuid { get; set; }
        public string fin { get; set; }

    }
}
