"""
ASGI config for syrinscapeDemo project.

It exposes the ASGI callable as a module-level variable named ``application``.

For more information on this file, see
https://docs.djangoproject.com/en/3.1/howto/deployment/asgi/
"""

# import os

# from django.core.asgi import get_asgi_application

# os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'syrinscapeDemo.settings')

# application = get_asgi_application()


import os
import django
from channels.http import AsgiHandler
from channels.routing import ProtocolTypeRouter

os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'syrinscapeDemo.settings')
django.setup()

# application = ProtocolTypeRouter({
#   "http": AsgiHandler(),
#   # Just HTTP for now. (We can add other protocols later.)
# })


# https://www.sitepoint.com/premium/books/django-channels-for-real-time-updates/read/1

from channels.generic.websocket import WebsocketConsumer
from django.conf.urls import url, include
class SocketConsumer(WebsocketConsumer):
    def connect(self):
        self.accept()
    def disconnect(self, close_code):
        pass
    def receive(self, text_data):
        "Handle incoming WebSocket data"
        if text_data == "echo":
            self.send(text_data="powpowpow")


websocket_urlpatterns = [
    url(r'^socket$',SocketConsumer.as_asgi()),
]


from channels.auth import AuthMiddlewareStack
from channels.routing import ProtocolTypeRouter, URLRouter
# import urls
application = ProtocolTypeRouter({
    'websocket': AuthMiddlewareStack(
        URLRouter(
           websocket_urlpatterns
        )
    ),
})