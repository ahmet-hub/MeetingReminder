﻿using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MeetingReminder.DataAccess.Concrete.EntityFramework
{
    public class EfMeetingDal:EntityRepositoryBase<Meeting,MeetingReminderContext>,IMeetingDal
    {

    }
}
