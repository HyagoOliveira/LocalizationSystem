using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Static Manager for Localization System.
    /// </summary>
    public static class LocalizationManager
    {
        /// <summary>
        /// Event fired when the language changes.
        /// </summary>
        public static event Action<Locale> OnLocaleChanged;

        /// <summary>
        /// Selects the given language.
        /// </summary>
        /// <param name="locale"></param>
        public static void Select(Locale locale)
        {
            LocalizationSettings.SelectedLocale = locale;
            OnLocaleChanged?.Invoke(locale);
        }

        /// <summary>
        /// Gets all available locales (languages) for the project.
        /// </summary>
        /// <returns>An asynchronous Task containing a list of languages.</returns>
        public static async Awaitable<List<Locale>> GetLocalesAsync()
        {
            await InitializeLocalizationAsync();
            return LocalizationSettings.AvailableLocales.Locales;
        }

        /// <summary>
        /// The index from the current locale (language).
        /// </summary>
        /// <param name="locales">A list of languages.</param>
        /// <returns></returns>
        public static int GetLocaleIndex(List<Locale> locales)
        {
            var currentLocale = LocalizationSettings.SelectedLocale;
            return locales.FindIndex(locale => locale == currentLocale);
        }

        /// <summary>
        /// Returns a human readable locale (language) name.
        /// </summary>
        /// <param name="locale"></param>
        /// <returns>Always a valid string.</returns>
        public static string GetDisplayName(Locale locale)
        {
            var name = locale.Identifier.CultureInfo != null ?
                locale.Identifier.CultureInfo.NativeName :
                locale.ToString();

            TryCaptalizeFirstLetter(ref name);

            return name;
        }

        // SelectedLocaleAsync will ensure that all locales have been initialized and a locale has been selected.
        private static async Awaitable InitializeLocalizationAsync() => await LocalizationSettings.SelectedLocaleAsync.Task;

        private static void TryCaptalizeFirstLetter(ref string text)
        {
            if (text.Length > 1) text = char.ToUpper(text[0]) + text[1..];
        }
    }
}