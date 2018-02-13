using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StringKing.StringFunctionInterface;
using StringKingProcessor;

namespace StringKingUI
{
    public class MacroRecorder
    {
        public enum Modes
        {
            NotRecording, Recording
        }

        public Modes Mode { get; private set; }
        public Macro NewMacro { get; private set; }

        public MacroRecorder()
        {
            Mode = Modes.NotRecording;
        }

        public void Record()
        {
            Mode = Modes.Recording;
            NewMacro = new Macro();
            NewMacro.Recorded = DateTime.Now;
        }

        public void Record(IStringFunction stringFunction, Dictionary<string, object> arguments)
        {
            NewMacro.Commands.Add(Processor.GetStringFunctionCallAsString(stringFunction, arguments));
        }

        public void StopRecording()
        {
            Mode = Modes.NotRecording;
        }

        internal void ShowRunMacroDialog()
        {
            throw new NotImplementedException();
        }
    }
}
