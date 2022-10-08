using System;
using System.Collections.Generic;
using System.Linq;
using CPanel.Models;
namespace CPanel.ViewModels
{
    public class jos_categories_ViewModel : jos_categories
    {
        public cpanelEntities entities = new cpanelEntities();
        private string _section_name;

        public string section_name
        {
            get
            {
                return Commons.CommonFunctionsAndProcedures.getSectionNameBySectionID(((section != null) && (section > 0)) ? (int)section : Commons.CommonFuncs.NUMBER_INVALID_INTEGER , entities);
            }
            set
            {
                _section_name = value;
            }
        }
    }
}