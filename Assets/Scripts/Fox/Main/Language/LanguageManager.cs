using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    public class LanguageManager : Manager<LanguageManager>
    {
        public string languageName { get; private set; }

        private Dictionary<string, LanguageInterpreter> interpreters = new Dictionary<string, LanguageInterpreter>();

        internal void InterpreterRegister(LanguageInterpreter interpreter)
        {
            interpreters.Add(interpreter.languageName, interpreter);
        }

        public void ChangeLanguage(string languageName)
        {
            this.languageName = languageName;
        }
    }
}