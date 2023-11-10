using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApiEntityLayer.Concrete
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionDetail { get;set;}
        public string AnswerDetail { get;set;}
    }
}
