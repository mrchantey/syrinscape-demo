FROM python:3.8.5

WORKDIR /usr/src/app

# RUN pip install django djangorestframework django-cors-headers
RUN pip install django djangorestframework django-cors-headers channels

COPY . .

CMD [ "python", "./manage.py","runserver", "0.0.0.0:7000"]