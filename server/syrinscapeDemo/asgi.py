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


from channels.routing import ProtocolTypeRouter, URLRouter
from channels.auth import AuthMiddlewareStack
from django.conf.urls import url, include
from channels.generic.websocket import WebsocketConsumer
import os
import django
from channels.http import AsgiHandler
from channels.routing import ProtocolTypeRouter
from syrinscapeDemo.urls import websocket_urlpatterns

os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'syrinscapeDemo.settings')
django.setup()

application = ProtocolTypeRouter({
    #   "http": AsgiHandler(),
    'websocket': AuthMiddlewareStack(
        URLRouter(
            websocket_urlpatterns
        )
    ),
})
