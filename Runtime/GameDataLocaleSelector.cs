using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using ActionCode.GameDataSystem;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Determines what localization should be used when the application starts based on any <see cref="AbstractGameData"/> implementation.
    /// <para>
    /// Add this selector in the Startup Selectors menu by going to Project Settings > Localization, Locale Selectors.
    /// </para>
    /// </summary>
    [Serializable]
    [DisplayName("Game Data Locale Selector")]
    public sealed class GameDataLocaleSelector : IStartupLocaleSelector
    {
        [SerializeField] private AbstractGameData data;

        public Locale GetStartupLocale(ILocalesProvider availableLocales) =>
            data.HasValidLanguage() ? availableLocales.GetLocale(data.languageCode) : null;
    }
}