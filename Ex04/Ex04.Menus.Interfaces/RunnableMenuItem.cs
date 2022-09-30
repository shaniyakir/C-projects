namespace Ex04.Menus.Interfaces
{
    public class RunnableMenuItem : MenuItem, IRunnable
    {
        private readonly IRunnable r_Operation;
        public RunnableMenuItem(string i_MenuTitle, IRunnable i_operation) : base(i_MenuTitle) 
        { 
            this.r_Operation = i_operation;
        }

        public void Run()
        {
            r_Operation.Run();
        }

        public IRunnable Operation
        {
            get { return r_Operation; }
        }
    }
}
