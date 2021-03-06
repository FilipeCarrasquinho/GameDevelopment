﻿using System;
using CharacterEditor.Character;

namespace CharacterEditor.Ioc.Api.Settings
{
    public delegate void AnimationIndexChangedHandler(int previousIndex, int newIndex);
    public delegate void FrameIndexChangedHandler(int previousIndex, int newIndex);
 
    public interface ISettings
    {
        string FileName { get; set; }

        int SelectedAnimationIndex { get; set; }
        int SelectedKeyFrameIndex { get; set; }
        int SelectedFrameIndex { get; set; }
        int SelectedPartIndex { get; set; }

        Animation SelectedAnimation { get; }
        KeyFrame SelectedKeyFrame { get; }
        Frame SelectedFrame { get; }
        Part SelectedPart { get; }

        event AnimationIndexChangedHandler SelectedAnimationIndexChanged;
        event FrameIndexChangedHandler SelectedFrameIndexChanged;
        event Action SelectedAnimationChanged;
        event Action SelectedKeyFrameChanged;
        event Action SelectedFrameChanged;
        event Action SelectedPartChanged;
    }
}