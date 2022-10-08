using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;

namespace CPanel.Models.Views
{
    public class TAO_BAI_THI_VIEW
    {
        private int _ID;
        private string _CAU_HOI;
        private string _DAP_AN;
        private string _STT;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public string CAU_HOI
        {
            get
            {
                return _CAU_HOI;
            }
            set
            {
                _CAU_HOI = value;
            }
        }

        public string DAP_AN
        {
            get
            {
                return _DAP_AN;
            }
            set
            {
                _DAP_AN = value;
            }
        }

        public string STT
        {
            get
            {
                return _STT;
            }
            set
            {
                _STT = value;
            }
        }


    }
}