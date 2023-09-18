using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    public abstract class LanguageInterpreter
    {
        public abstract string languageName { get; }
        public abstract string GetText(int id);

        public LanguageInterpreter()
        {
            LanguageManager.instance.InterpreterRegister(this);
        }
    }
}