using System;
using System.Collections.Generic;
using System.Text;

namespace log2excel
{
    class Parser
    {
        private string text = null;
        private int pos = 0;
        private int length = 0;

        public Parser(string text)
        {
            if (text == null) throw new ArgumentNullException("text");
            //
            this.text = text;
            this.length = text.Length;
        }

        public bool Ended { get { return this.pos >= this.length; } }

        public char Current { get { return this.text[this.pos]; } }

        public string ReadSpace()
        {
            int startPos = this.pos;
            //
            while ((this.pos < this.length) && char.IsWhiteSpace(this.text[this.pos]))
            {
                this.pos++;
            }
            //
            return this.text.Substring(startPos, this.pos - startPos);
        }

        public string ReadNonSpace()
        {
            int startPos = this.pos;
            //
            while ((this.pos < this.length) && !char.IsWhiteSpace(this.text[this.pos]))
            {
                this.pos++;
            }
            //
            return this.text.Substring(startPos, this.pos - startPos);
        }

        //public string ReadToCharIncluding(char stopChar)
        //{
        //    int startPos = this.pos;
        //    //
        //    while ((this.pos < this.length) && (this.text[this.pos] != stopChar))
        //    {
        //        this.pos++;
        //    }
        //    //
        //    return this.text.Substring(startPos, this.pos - startPos);
        //}

        public string ReadEnclosed(char stopChar)
        {
            int startPos = this.pos;
            this.pos++;
            //
            while ((this.pos < this.length) && (this.text[this.pos] != stopChar))
            {
                this.pos++;
            }
            if (this.pos < this.length) this.pos++;
            //
            return this.text.Substring(startPos, this.pos - startPos);
        }

        //public char ReadNextChar()
        //{
        //    if (this.pos >= this.length) throw new Exception("ReadNextChar(): parser text is ended");
        //    this.pos++;
        //    return this.Current;
        //}

    }
}
