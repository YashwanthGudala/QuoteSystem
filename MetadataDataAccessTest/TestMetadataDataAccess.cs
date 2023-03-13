﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteSystemDataModel;
using QuoteSystemDataAccess;

namespace MetadataDataAccessTest
{
    class TestMetadataDataAccess
    {
        public static void AddCodeValueToListTest()
        {
            Console.WriteLine("Enter List Name");
            string listname = Console.ReadLine();
            Console.WriteLine("Enter Code : ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Value : ");
            string value = Console.ReadLine();

            CodeValue codeValue = new CodeValue()
            {
                Code = code,
                Value = value
            };


            string res = QuoteSystemDataAccess.CodeValueDataAccess.AddCodeValue(listname, codeValue);
            Console.WriteLine(res);

        }
        public static void AddNewCodeValueListTest()
        {
            Console.WriteLine("Enter List Name");
            string newlist = Console.ReadLine();

            string res = QuoteSystemDataAccess.CodeValueDataAccess.AddCodeValueList(newlist);
            Console.WriteLine(res);
        }
        public static void ViewAllCodeValueListsTest()
        {
            List<CodeValueList> codeValueLists = QuoteSystemDataAccess.CodeValueDataAccess.GetAllCodeValueLists();

            foreach(var list in codeValueLists)
            {
                Console.WriteLine(list.ListName);
            }
        }
        public static void DeleteCodeValueListTest()
        {
            Console.WriteLine("Enter List name");
            string listname = Console.ReadLine();
            string res = QuoteSystemDataAccess.CodeValueDataAccess.DeleteCodeValueList(listname);
            Console.WriteLine(res);
        }

        
    }
}