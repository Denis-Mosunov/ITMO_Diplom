PGDMP  0    2                }            calibration_certificates    16.8    16.8 %               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    17272    calibration_certificates    DATABASE     �   CREATE DATABASE calibration_certificates WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
 (   DROP DATABASE calibration_certificates;
                postgres    false            �            1259    25493    certificates    TABLE     �  CREATE TABLE public.certificates (
    id integer NOT NULL,
    device_id integer NOT NULL,
    standard_id integer NOT NULL,
    calibrator_id integer NOT NULL,
    chief_metrologist_id integer NOT NULL,
    temperature double precision NOT NULL,
    humidity double precision NOT NULL,
    pressure numeric(100,0) NOT NULL,
    voltage numeric(1000,0) NOT NULL,
    calibration_date date DEFAULT CURRENT_DATE NOT NULL
);
     DROP TABLE public.certificates;
       public         heap    postgres    false            �            1259    25492    certificates_id_seq    SEQUENCE     �   CREATE SEQUENCE public.certificates_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.certificates_id_seq;
       public          postgres    false    222                       0    0    certificates_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.certificates_id_seq OWNED BY public.certificates.id;
          public          postgres    false    221            �            1259    25484    devices    TABLE     F  CREATE TABLE public.devices (
    id integer NOT NULL,
    device_name character varying(30) NOT NULL,
    factory_number character varying(40) NOT NULL,
    inventory_number character varying(40) NOT NULL,
    periodicity integer NOT NULL,
    document_name character varying(30) NOT NULL,
    department integer NOT NULL
);
    DROP TABLE public.devices;
       public         heap    postgres    false            �            1259    25483    devices_id_seq    SEQUENCE     �   CREATE SEQUENCE public.devices_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.devices_id_seq;
       public          postgres    false    220                       0    0    devices_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.devices_id_seq OWNED BY public.devices.id;
          public          postgres    false    219            �            1259    25477 	   standards    TABLE     �   CREATE TABLE public.standards (
    id integer NOT NULL,
    standard_name character varying(40) NOT NULL,
    factory_number character varying(50) NOT NULL
);
    DROP TABLE public.standards;
       public         heap    postgres    false            �            1259    25476    standards_id_seq    SEQUENCE     �   CREATE SEQUENCE public.standards_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.standards_id_seq;
       public          postgres    false    218                       0    0    standards_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.standards_id_seq OWNED BY public.standards.id;
          public          postgres    false    217            �            1259    25468    users    TABLE     �   CREATE TABLE public.users (
    id integer NOT NULL,
    username character varying(50) NOT NULL,
    password character varying(10) NOT NULL,
    role character varying(50)
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    25467    users_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.users_id_seq;
       public          postgres    false    216                       0    0    users_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;
          public          postgres    false    215            c           2604    25496    certificates id    DEFAULT     r   ALTER TABLE ONLY public.certificates ALTER COLUMN id SET DEFAULT nextval('public.certificates_id_seq'::regclass);
 >   ALTER TABLE public.certificates ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    222    221    222            b           2604    25487 
   devices id    DEFAULT     h   ALTER TABLE ONLY public.devices ALTER COLUMN id SET DEFAULT nextval('public.devices_id_seq'::regclass);
 9   ALTER TABLE public.devices ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    219    220            a           2604    25480    standards id    DEFAULT     l   ALTER TABLE ONLY public.standards ALTER COLUMN id SET DEFAULT nextval('public.standards_id_seq'::regclass);
 ;   ALTER TABLE public.standards ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    218    217    218            `           2604    25471    users id    DEFAULT     d   ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);
 7   ALTER TABLE public.users ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    215    216            	          0    25493    certificates 
   TABLE DATA           �   COPY public.certificates (id, device_id, standard_id, calibrator_id, chief_metrologist_id, temperature, humidity, pressure, voltage, calibration_date) FROM stdin;
    public          postgres    false    222   �+                 0    25484    devices 
   TABLE DATA           |   COPY public.devices (id, device_name, factory_number, inventory_number, periodicity, document_name, department) FROM stdin;
    public          postgres    false    220   �+                 0    25477 	   standards 
   TABLE DATA           F   COPY public.standards (id, standard_name, factory_number) FROM stdin;
    public          postgres    false    218   �,                 0    25468    users 
   TABLE DATA           =   COPY public.users (id, username, password, role) FROM stdin;
    public          postgres    false    216   n-                  0    0    certificates_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.certificates_id_seq', 8, true);
          public          postgres    false    221                       0    0    devices_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.devices_id_seq', 5, true);
          public          postgres    false    219                       0    0    standards_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.standards_id_seq', 5, true);
          public          postgres    false    217                       0    0    users_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.users_id_seq', 9, true);
          public          postgres    false    215            n           2606    25499    certificates certificates_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.certificates
    ADD CONSTRAINT certificates_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.certificates DROP CONSTRAINT certificates_pkey;
       public            postgres    false    222            l           2606    25491    devices devices_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.devices
    ADD CONSTRAINT devices_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.devices DROP CONSTRAINT devices_pkey;
       public            postgres    false    220            j           2606    25482    standards standards_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.standards
    ADD CONSTRAINT standards_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.standards DROP CONSTRAINT standards_pkey;
       public            postgres    false    218            f           2606    25473    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    216            h           2606    25475    users users_username_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);
 B   ALTER TABLE ONLY public.users DROP CONSTRAINT users_username_key;
       public            postgres    false    216            o           2606    25510 ,   certificates certificates_calibrator_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.certificates
    ADD CONSTRAINT certificates_calibrator_id_fkey FOREIGN KEY (calibrator_id) REFERENCES public.users(id);
 V   ALTER TABLE ONLY public.certificates DROP CONSTRAINT certificates_calibrator_id_fkey;
       public          postgres    false    222    216    4710            p           2606    25515 3   certificates certificates_chief_metrologist_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.certificates
    ADD CONSTRAINT certificates_chief_metrologist_id_fkey FOREIGN KEY (chief_metrologist_id) REFERENCES public.users(id);
 ]   ALTER TABLE ONLY public.certificates DROP CONSTRAINT certificates_chief_metrologist_id_fkey;
       public          postgres    false    216    222    4710            q           2606    25500 (   certificates certificates_device_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.certificates
    ADD CONSTRAINT certificates_device_id_fkey FOREIGN KEY (device_id) REFERENCES public.devices(id);
 R   ALTER TABLE ONLY public.certificates DROP CONSTRAINT certificates_device_id_fkey;
       public          postgres    false    4716    220    222            r           2606    25505 *   certificates certificates_standard_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.certificates
    ADD CONSTRAINT certificates_standard_id_fkey FOREIGN KEY (standard_id) REFERENCES public.standards(id);
 T   ALTER TABLE ONLY public.certificates DROP CONSTRAINT certificates_standard_id_fkey;
       public          postgres    false    218    4714    222            	      x������ � �         �   x��нJA�z�)�6���ݥA��+&��Mr�"g
�S9�D���F��FS��o>Ha���F/�����[)����2��͒:;9��Α:��2y�/x��T�D�VQ�#-�5�A�]OQ?�^����G���w�D�:�N;|1�F3�6x0��b^ڪ3hi��o{���?�fj�ь�8�F�/C�Ǖ���S�;���-���J��x�.�O8�p��	jSf��&}=�Z��`��         �   x�3估�bӅv_�wa�����/l��pa�Ŧ��.v+\X�k�����k``�e���� s�����;.�+\����a���zÅm@��.6%v(\�����a��c/���~�.�=�-a�>!`=�hz� =��@/́(�u�:(F��� ^4��         \   x�3�LL��̃��FƜ���i\f��e�y�e����`�Ĝ̤�Ē�".s΂Ԓ"������gqfJ>L���j�%gIjq	�@3-F��� n6*�     