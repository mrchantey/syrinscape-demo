# from django.contrib import admin
# from django.urls import path

# urlpatterns = [
#	 path('admin/', admin.site.urls),
# ]

from django.conf.urls import url
from syrinscapeDemo.game import weapon_req, enemy_req, SocketConsumer

urlpatterns = [
	url(r'^weapon$', weapon_req),
	url(r'^enemy$', enemy_req),
]

websocket_urlpatterns = [
	url(r'^socket$', SocketConsumer.as_asgi()),
]
