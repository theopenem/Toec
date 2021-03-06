﻿using Newtonsoft.Json;
using System;
using System.Security.Principal;
using Toec_Common.Dto;
using Toec_Services;

namespace Toec.Commands
{
    
    public class CommandPrepareImage : ICommand
    {
        private readonly string[] _args;
        public CommandPrepareImage(string[] args)
        {
            _args = args;
        }

        
        public void Run()
        {
            if (!HasAdministrativeRight())
            {
                Console.WriteLine("Administrative Privileges Required To Prepare For Image");
            }
            else
            {
                Console.WriteLine("Toec Prepare Image Initiated");
                var imagePrepOptions = new DtoImagePrepOptions();
                imagePrepOptions.ResetToec = true;
                new ServicePrepareImage().Run(imagePrepOptions);
            }
        }

        public static bool HasAdministrativeRight()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}