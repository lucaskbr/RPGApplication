﻿using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class AttributeInCharacterDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();
        
        public static AttributeInCharacter Get(int? id)
        {
            AttributeInCharacter attributesInCharacter = new AttributeInCharacter();

            try
            {
                attributesInCharacter = ctx.AttributeInCharacters.Find(id);
            }
            catch (Exception e) { }

            return attributesInCharacter;

        }

        public static void Update(AttributeInCharacter attributeInCharacter)
        {
            ctx.Entry(attributeInCharacter).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}