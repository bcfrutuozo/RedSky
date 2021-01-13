using System;
using System.Collections.Generic;
using AutoMapper;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Presentation.Web.ViewModels
{
    public class DropdownViewModel
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}