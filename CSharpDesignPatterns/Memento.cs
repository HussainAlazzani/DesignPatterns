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
    public class Editor
    {
        public string Content { get; set; }

        public EditorState CreateState()
        {
            return new EditorState(Content);
        }

        public void Restore(EditorState state)
        {
            Content = state.Content;
        }
    }

    /// <summary>
    /// Momento.
    /// </summary>
    public class EditorState
    {
        public EditorState(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }

    /// <summary>
    /// Caretaker.
    /// </summary>
    public class History
    {
        private Stack<EditorState> states = new Stack<EditorState>();

        public void Push(EditorState state)
        {
            states.Push(state);
        }

        public EditorState Pop()
        {
            states.Pop();
            return states.Peek();
        }
    }
}