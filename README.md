# 🏎️ Racing Game 3D

مشروع سباق سيارات ثلاثي الأبعاد مخصص للموبايل والويب باستخدام Unity.

## الخطوات السريعة

1. افتح المشروع في Unity Hub.
2. اختر مجلد المشروع.
3. أضف Scene جديد باسم `MainScene`.
4. أضف كائنات اللاعب والطريق والسيارات المنافسة.
5. اربط Scripts بالـ GameObjects.
6. انتقل إلى Build Settings واختر WebGL أو Android.
7. شغّل المشروع في المتصفح أو أنشئ APK.

## الملفات الأساسية

- `Assets/Scripts/CarController.cs`
- `Assets/Scripts/EnemyAI.cs`
- `Assets/Scripts/RoadGenerator.cs`
- `Assets/Scripts/GameUI.cs`
- `Assets/Scripts/CollisionDetector.cs`

## الربط في Unity

- أضف سيارة Player.
- أرفق `CarController`.
- أضف Rigidbody و Collider.
- أضف `GameUI` إلى كائن UI.
- أضف `RoadGenerator` إلى كائن فارغ.
- اجعل الطريق prefab موجودًا.
- أضف سيارات منافسة مع `EnemyAI`.

## ربط معاينة الويب

بعد Build → WebGL يمكنك رفع النتائج على:
- GitHub Pages
- Netlify
- itch.io

## ملاحظات

هذا مشروع أساسي قابل للتوسع، ولا يزال يحتاج:
- موديلات سيارات 3D
- أضواء/إضاءة واقعية
- بيئة طريق ومباني
- أصوات محرك
- واجهة احترافية

---

تم إعداد المشروع كقاعدة أولية لتطوير لعبة سباق سيارات 3D واقعية.
