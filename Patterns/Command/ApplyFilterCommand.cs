using System.Drawing;
using ImageEditorApp.Patterns.Strategy;
using ImageEditorApp.Services;

namespace ImageEditorApp.Patterns.Command
{
    public class ApplyFilterCommand : ICommand
    {
        private readonly EditingService _service;
        private readonly IImageFilter _filter;
        private Bitmap _before;
        private Bitmap _after;

        public ApplyFilterCommand(EditingService service, IImageFilter filter)
        {
            _service = service;
            _filter = filter;
        }

        public void Execute()
        {
            _before = _service.GetCurrentBitmap()?.Clone() as Bitmap;
            _after = _filter.Apply(_before);
            _service.SetCurrentBitmap(_after);
            _service.AddHistory($"Filter: {_filter.Name}");
        }

        public void Undo()
        {
            if (_before != null)
            {
                _service.SetCurrentBitmap(_before);
                _service.AddHistory($"Undo: {_filter.Name}");
            }
        }
    }
}
