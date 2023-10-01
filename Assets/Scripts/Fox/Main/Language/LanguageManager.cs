using System.Collections;
using System.Collections.Generic;

namespace Fox
{
    using Language;
    public class LanguageManager : Manager<LanguageManager>
    {
        public string languageName => interpreter.languageName;

        private LanguageInterpreter interpreter;

        private Dictionary<string, LanguageInterpreter> interpreters = new Dictionary<string, LanguageInterpreter>();

        internal void InterpreterRegister(in LanguageInterpreter interpreter)
        {
            interpreters.Add(interpreter.languageName, interpreter);
        }

        public void ChangeLanguage(in string languageName)
        {
            if (interpreters.TryGetValue(languageName, out var interpreter))
            {
                this.interpreter = interpreter;
            }
        }

        public string GetText(in uint id)
        {
            return interpreter.GetText(in id);
        }
    }
}