﻿using CharacterEditor.Ioc.Api.Settings;
using Funq.Fast;
using GraphicalUserInterfaceLib.Api;

// ReSharper disable ForCanBeConvertedToForeach
namespace CharacterEditor.Editor.Controls.KeyFrames
{
    public class DurationControls : IControlComponent, ITextControl
    {
        private readonly IKeyFramesScroll _keyFramesScroll;
        private readonly IReadOnlySettings _settings;
        private readonly DurationControl[] _durationControls;

        public DurationControls(int x, int y, int yIncrement, IKeyFramesScroll keyFramesScroll)
        {
            _keyFramesScroll = keyFramesScroll;
            _settings = DependencyInjection.Resolve<IReadOnlySettings>();
            _durationControls = new DurationControl[_keyFramesScroll.Limit];

            for (var i = 0; i < _durationControls.Length; i++)
                _durationControls[i] = new DurationControl(x, y + (i * yIncrement));

            _keyFramesScroll.ScrollIndexChanged += UpdateControls;
            _settings.SelectedAnimationChanged += UpdateControls;
            UpdateControls();
        }

        private void UpdateControls()
        {
            for (var i = 0; i < _durationControls.Length; i++)
            {
                var keyFrame = _settings.SelectedAnimation.KeyFrames[_keyFramesScroll.ScrollIndex + i];
                _durationControls[i].KeyFrame = keyFrame;
            }
        }

        public void Update()
        {
            for (var i = 0; i < _durationControls.Length; i++)
                _durationControls[i].Update();
        }

        public void Draw()
        {
            for (var i = 0; i < _durationControls.Length; i++)
                _durationControls[i].Draw();
        }
    }
}
