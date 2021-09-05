using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKamp.MvcUI
{
    public static class ToastrService
    {
        private static readonly List<Toastr > _toastrs 
            = new List<Toastr>();

        public static string GetSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static void AddToQueue(Toastr toastr)
        {
            _toastrs.Add(toastr);
        }

        public static void AddToQueue(string message, string title, ToastrType type)
        {
            AddToQueue(new Toastr(message, title, type));
        }

     

        public static void ClearAll()
        {
            _toastrs.Clear();
        }

        public static List<Toastr> ReadUserQueue()
        {
             var list = _toastrs.ToList();
            ClearAll();
            return list;
           
        }

    }
}