using UnityEngine;
using UnityEngine.Localization;
using ActionCode.GameDataSystem;

namespace ActionCode.LocalizationSystem
{
    /// <summary>
    /// Handler for <see cref="LocalizationManager.OnLocaleChanged"/>.
    /// Sets the LanguageCode in the GameData.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class GameDataLocaleHandler : MonoBehaviour
    {
        [SerializeField] private AbstractGameData data;

        private void OnEnable() => LocalizationManager.OnLocaleChanged += HandleLocaleChanged;
        private void OnDisable() => LocalizationManager.OnLocaleChanged -= HandleLocaleChanged;

        private void HandleLocaleChanged(Locale locale) => data.Settings.LanguageCode = locale.Identifier.Code;
    }
}