using SeriousGameToolbox.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    /// <summary>
    /// A Command that is triggered by a key sequence, useful for handling debugging cases (like restarting a phase)
    /// </summary>
    public class Command : IEquatable<Command>
    {
        private string effect = CommandEffects.NoEffect;

        public string Effect
        {
            get { return effect; }
        }

        private string[] sequence;

        public string[] Sequence
        {
            get { return sequence; }
        }

        public string ConcatenatedForm { get; private set; }

        private Command(string effect, string[] sequence)
        {
            this.effect = effect;
            this.sequence = sequence;
            this.ConcatenatedForm = Concatenate(sequence);
        }

        public static Command CreateCommand(string effect, params string[] sequence)
        {
            Guard.AgainstNullArgument("sequence", sequence);
            Guard.AgainstNullArgument("effect", effect);

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = sequence[i].ToUpperInvariant();
            }

            if (SequenceIsValid(sequence))
            {
                return new Command(effect, sequence);
            }
            else
            {
                throw new ArgumentException("The provided sequence is invalid : " + Concatenate(sequence));
            }
        }

        public static string Concatenate(params string[] sequence)
        {
            string s = sequence[0].ToUpperInvariant();

            if (sequence.Length > 1)
            {
                s += "+" + sequence[1].ToUpperInvariant();
            }

            if (sequence.Length > 2)
            {
                s += "+" + sequence[2].ToUpperInvariant();
            }

            if (sequence.Length > 3)
            {
                s += "+" + sequence[3].ToUpperInvariant();
            }

            return s;
        }

        /// <summary>
        /// A valid sequence must starts with the CTRL key,
        /// then continues with :
        /// - SHIFT, or
        /// - ALT, or
        /// - a letter
        /// then finish with :
        /// - a letter
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private static bool SequenceIsValid(string[] sequence)
        {
            Guard.AgainstNullArgument("sequence", sequence);

            int length = sequence.Length;

            if (length < 2)
            {
                return false;
            }

            if (length == 2)
            {
                if (sequence[0] == Keys.CTRL)
                {
                    if (Keys.AnyLetter(sequence[1]))
                    {
                        return true;
                    }
                }
            }

            if (length == 3)
            {
                if (sequence[0] == Keys.CTRL)
                {
                    if (sequence[1] == Keys.SHIFT)
                    {
                        if (Keys.AnyLetter(sequence[2]))
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }

        public override int GetHashCode()
        {
            return effect.GetHashCode() + sequence.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Command)
            {
                return Equals(obj as Command);
            }

            return false;
        }

        public bool Equals(Command other)
        {
            return Concatenate(other.sequence) == Concatenate(this.sequence) && other.effect == this.effect;
        }

        public override string ToString()
        {
            return string.Format("Command : {0} => {1}", Concatenate(sequence), effect);
        }
    }
}
