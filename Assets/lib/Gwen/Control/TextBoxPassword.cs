﻿using System;

namespace Gwen.Control
{
    /// <summary>
    /// Text box with masked text.
    /// </summary>
    /// <remarks>
    /// This class doesn't prevent programatic access to the text in any way.
    /// </remarks>
    public class TextBoxPassword : TextBox
    {
        private string m_Mask;
        private char m_MaskCharacter;

        /// <summary>
        /// Character used in place of actual characters for display.
        /// </summary>
        public char MaskCharacter { get { return m_MaskCharacter; } set { m_MaskCharacter = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxPassword"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public TextBoxPassword(Base parent)
            : base(parent)
        {
            m_MaskCharacter = '*';
        }

        /// <summary>
        /// Handler for text changed event.
        /// </summary>
        protected override void OnTextChanged()
        {
            m_Mask = new String(MaskCharacter, Text.Length);
            TextOverride = m_Mask;
            base.OnTextChanged();
            //Really hacky way to make sure the size for the mask is calculated.
            base.Children[0].SizeToChildren();
        }
    }
}
