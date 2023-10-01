using System.Collections;
using System.Collections.Generic;

namespace Fox.Language
{
    public abstract class LanguageInterpreter
    {
        public abstract string languageName { get; }
        public abstract string GetText(in uint id);

        public LanguageInterpreter()
        {
            LanguageManager.instance.InterpreterRegister(this);
        }
    }
}