import sys
from win10toast import ToastNotifier
Argument = sys.argv
toaster = ToastNotifier()
toaster.show_toast("دستیار فارسی08", "برای اطلاع از دستورات راهنما را بفرستید", "Icon (2).ico")