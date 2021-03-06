﻿using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {
        // Extract members common to SearchJobsViewModel
        // to BaseViewModel

        // All fields in the given column
        public IEnumerable<JobField> Fields { get; set; }
    }
}
