﻿#region License

// 
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using System;

namespace DateTimeExtensions.WorkingDays
{
    public class VariableHoliday : Holiday
    {
        private readonly Func<int, DateTime?> yearToHoliday;

        public VariableHoliday(string name, Func<int, DateTime?> yearToHoliday)
            : base(name)
        {
            this.yearToHoliday = yearToHoliday;
        }

        public override DateTime? GetInstance(int year)
        {
            return this.yearToHoliday(year);
        }

        public override bool IsInstanceOf(DateTime date)
        {
            var holidayDate = this.yearToHoliday(date.Year);
            return holidayDate != null && holidayDate.Value.Date == date.Date;
        }
    }
}