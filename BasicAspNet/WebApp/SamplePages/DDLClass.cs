﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.SamplePages
{
    public class DDLClass
    {
        public string DisplayField { get; set; }
        public int ValueField { get; set; }

        public DDLClass()
        {

        }

        public DDLClass(int valuefield, string displayfield)
        {
           
            DisplayField = displayfield;
            ValueField = valuefield;
        }

    }
}