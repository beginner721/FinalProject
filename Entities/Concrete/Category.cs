﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın, IEntity ile bağlayalım!
    public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
