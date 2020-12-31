using System.Collections.Generic;

namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class MementoTest
    {
        public static void Run()
        {
            var editor = new Editor();
            var history = new History();
            editor.Content = "a";
            history.Push(editor.CreateState());
            editor.Content = "b";
            history.Push(editor.CreateState());
            editor.Restore(history.Pop());
            System.Console.WriteLine(editor.Content);
            editor.Content = "c";
            history.Push(editor.CreateState());
            System.Console.WriteLine(editor.Content);
            editor.Restore(history.Pop());
            System.Console.WriteLine(editor.Content);
        }
    }

    /// <summary>
    /// Originator.
    /// </summary>
    internal class Editor
    {
        internal string Content { get; set; }

        internal EditorState CreateState()
        {
            return new EditorState(Content);
        }

        internal void Restore(EditorState state)
        {
            Content = state.Content;
        }
    }

    /// <summary>
    /// Momento.
    /// </summary>
    internal class EditorState
    {
        internal EditorState(string content)
        {
            Content = content;
        }

        internal string Content { get; }
    }

    /// <summary>
    /// Caretaker.
    /// </summary>
    internal class History
    {
        private Stack<EditorState> states = new Stack<EditorState>();

        internal void Push(EditorState state)
        {
            states.Push(state);
        }

        internal EditorState Pop()
        {
            states.Pop();
            return states.Peek();
        }
    }
}