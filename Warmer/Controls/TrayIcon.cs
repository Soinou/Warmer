using System;
using System.Drawing;
using System.Windows.Forms;
using Warmer.Utils;

namespace Warmer.Controls
{
    /// <summary>
    /// Represents a tray icon, using the System.Windows.Forms.NotifyIcon
    /// </summary>
    public class TrayIcon : DisposableBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Tooltip text of the icon</param>
        /// <param name="icon">Icon</param>
        public TrayIcon(string text, Icon icon)
        {
            icon_ = new NotifyIcon();
            menu_ = new ContextMenu();

            icon_.Icon = icon;
            icon_.Text = text;
            icon_.MouseDoubleClick += OnDoubleClick;
            icon_.BalloonTipClicked += OnBalloonTipClick;
            icon_.ContextMenu = menu_;
        }

        /// <summary>
        /// Gets the number of items in the tray icon menu
        /// </summary>
        public int ItemCount
        {
            get
            {
                return menu_.MenuItems.Count;
            }
        }

        /// <summary>
        /// Adds a new item to the tray icon menu
        /// </summary>
        /// <param name="name">Name of the item</param>
        public void AddItem(string name)
        {
            MenuItem item = new MenuItem();
            item.Text = name;
            item.Click += (object sender, EventArgs e) =>
            {
                ItemClicked?.Invoke(name);
            };
            menu_.MenuItems.Add(item);
        }

        /// <summary>
        /// Adds a separator to the tray icon menu
        /// </summary>
        public void AddSeparator()
        {
            menu_.MenuItems.Add("-");
        }

        /// <summary>
        /// Hides the tray icon
        /// </summary>
        public void Hide()
        {
            icon_.Visible = false;
        }

        /// <summary>
        /// Show a balloon tip notification
        /// </summary>
        /// <param name="title">Notification title</param>
        /// <param name="message">Notification message</param>
        public void Notify(string title, string message)
        {
            icon_.ShowBalloonTip(1000, title, message, ToolTipIcon.Info);
        }

        /// <summary>
        /// Shows the tray icon
        /// </summary>
        public void Show()
        {
            icon_.Visible = true;
        }

        /// <summary>
        /// Icon double clicked
        /// </summary>
        public event DataEventHandler DoubleClicked;

        /// <summary>
        /// Menu item clicked
        /// </summary>
        public event DataEventHandler<string> ItemClicked;

        /// <summary>
        /// Notification clicked
        /// </summary>
        public event DataEventHandler NotificationClicked;

        /// <inheritdoc />
        protected override void OnFinalize()
        {
            menu_.Dispose();
            icon_.Dispose();
        }

        /// <summary>
        /// Called when the balloon tip notification is clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void OnBalloonTipClick(object sender, EventArgs e)
        {
            NotificationClicked?.Invoke();
        }

        /// <summary>
        /// Called when the icon is double clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private void OnDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClicked?.Invoke();
        }

        /// <summary>
        /// Notify icon
        /// </summary>
        private NotifyIcon icon_;

        /// <summary>
        /// Context menu
        /// </summary>
        private ContextMenu menu_;
    }
}
