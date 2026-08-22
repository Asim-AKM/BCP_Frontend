/* ==========================================================================
   BloodConnect.pk — Hero 3D Network & Scroll Animations
   ========================================================================== */

function initPublicPageScript() {
    // 1. 3D Canvas Animation Initialization
    const canvas = document.getElementById('hero-3d-canvas');
    if (canvas && typeof THREE !== 'undefined' && canvas.dataset.initialized !== "true") {
        canvas.dataset.initialized = "true";

        const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
        let width = canvas.clientWidth || window.innerWidth;
        let height = canvas.clientHeight || 500;

        const scene = new THREE.Scene();
        const camera = new THREE.PerspectiveCamera(50, width / height, 0.1, 100);
        camera.position.set(0, 0, 13);

        const renderer = new THREE.WebGLRenderer({ canvas, alpha: true, antialias: true });
        renderer.setPixelRatio(Math.min(window.devicePixelRatio, 1.6));
        renderer.setSize(width, height, false);

        const network = new THREE.Group();
        scene.add(network);

        function makeGlowTexture(hex) {
            const size = 128;
            const c = document.createElement('canvas');
            c.width = c.height = size;
            const ctx = c.getContext('2d');
            const grd = ctx.createRadialGradient(size / 2, size / 2, 0, size / 2, size / 2, size / 2);
            grd.addColorStop(0, hex + 'ff');
            grd.addColorStop(0.35, hex + 'aa');
            grd.addColorStop(1, hex + '00');
            ctx.fillStyle = grd;
            ctx.fillRect(0, 0, size, size);
            return new THREE.CanvasTexture(c);
        }

        const glowBlood = makeGlowTexture('#ff2d55');
        const glowVital = makeGlowTexture('#3ee6c4');
        const glowIce = makeGlowTexture('#5ec8ff');

        const globeGeo = new THREE.IcosahedronGeometry(4.3, 2);
        const edges = new THREE.EdgesGeometry(globeGeo);
        const globeMat = new THREE.LineBasicMaterial({ color: 0x2a3355, transparent: true, opacity: 0.55 });
        const globeWire = new THREE.LineSegments(edges, globeMat);
        network.add(globeWire);

        const positionAttr = globeGeo.getAttribute('position');
        const allPoints = [];
        for (let i = 0; i < positionAttr.count; i++) {
            allPoints.push(new THREE.Vector3(positionAttr.getX(i), positionAttr.getY(i), positionAttr.getZ(i)));
        }
        const uniquePoints = [];
        allPoints.forEach((p) => {
            if (!uniquePoints.some((q) => q.distanceTo(p) < 0.05)) uniquePoints.push(p);
        });
        const nodeCount = Math.min(46, uniquePoints.length);
        const nodes = [];
        for (let i = uniquePoints.length - 1; i > 0 && nodes.length < nodeCount; i -= Math.max(1, Math.floor(uniquePoints.length / nodeCount))) {
            nodes.push(uniquePoints[i]);
        }

        const spriteMaterials = [glowBlood, glowVital, glowIce];
        nodes.forEach((pos, i) => {
            const tex = spriteMaterials[i % spriteMaterials.length];
            const mat = new THREE.SpriteMaterial({ map: tex, transparent: true, depthWrite: false, blending: THREE.AdditiveBlending });
            const sprite = new THREE.Sprite(mat);
            const scale = 0.22 + Math.random() * 0.18;
            sprite.scale.set(scale, scale, 1);
            sprite.position.copy(pos);
            network.add(sprite);
        });

        const connectionCount = 16;
        const connections = [];
        for (let i = 0; i < connectionCount; i++) {
            const a = nodes[Math.floor(Math.random() * nodes.length)];
            const b = nodes[Math.floor(Math.random() * nodes.length)];
            if (!a || !b || a === b) continue;

            const mid = a.clone().add(b).multiplyScalar(0.5).normalize().multiplyScalar(5.1);
            const curve = new THREE.QuadraticBezierCurve3(a, mid, b);
            const points = curve.getPoints(24);
            const geo = new THREE.BufferGeometry().setFromPoints(points);
            const mat = new THREE.LineBasicMaterial({
                color: Math.random() > 0.5 ? 0xff2d55 : 0x3ee6c4,
                transparent: true,
                opacity: 0,
                blending: THREE.AdditiveBlending,
            });
            const line = new THREE.Line(geo, mat);
            network.add(line);
            connections.push({ line, phase: Math.random() * Math.PI * 2, speed: 0.6 + Math.random() * 0.6 });
        }

        const starGeo = new THREE.BufferGeometry();
        const starCount = 250;
        const starPos = new Float32Array(starCount * 3);
        for (let i = 0; i < starCount; i++) {
            starPos[i * 3] = (Math.random() - 0.5) * 40;
            starPos[i * 3 + 1] = (Math.random() - 0.5) * 40;
            starPos[i * 3 + 2] = (Math.random() - 0.5) * 40 - 5;
        }
        starGeo.setAttribute('position', new THREE.BufferAttribute(starPos, 3));
        const starMat = new THREE.PointsMaterial({ color: 0x3a4570, size: 0.045, transparent: true, opacity: 0.6 });
        const stars = new THREE.Points(starGeo, starMat);
        scene.add(stars);

        let pointerX = 0, pointerY = 0;
        window.addEventListener('pointermove', (e) => {
            pointerX = (e.clientX / window.innerWidth) - 0.5;
            pointerY = (e.clientY / window.innerHeight) - 0.5;
        });

        function onResize() {
            width = canvas.clientWidth;
            height = canvas.clientHeight;
            if (!width || !height) return;
            camera.aspect = width / height;
            camera.updateProjectionMatrix();
            renderer.setSize(width, height, false);
        }
        window.addEventListener('resize', onResize);

        const clock = new THREE.Clock();

        function animate() {
            requestAnimationFrame(animate);
            if (document.hidden) return;

            const t = clock.getElapsedTime();

            if (!prefersReducedMotion) {
                network.rotation.y = t * 0.09 + pointerX * 0.4;
                network.rotation.x = Math.sin(t * 0.15) * 0.08 + pointerY * 0.25;
                stars.rotation.y = t * 0.01;
            }

            connections.forEach((c) => {
                const wave = (Math.sin(t * c.speed + c.phase) + 1) / 2;
                c.line.material.opacity = Math.max(0, wave - 0.35) * 1.4;
            });

            renderer.render(scene, camera);
        }

        onResize();
        animate();
    }

    // 2. Scroll Reveal Animation for Sections
    const reveals = document.querySelectorAll('.reveal');
    const revealObserver = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('active');
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.1, rootMargin: '0px 0px -50px 0px' });

    reveals.forEach(el => {
        if (!el.style.opacity) {
            el.style.opacity = '0';
            el.style.transform = 'translateY(20px)';
            el.style.transition = 'opacity 0.6s ease-out, transform 0.6s ease-out';
        }
        revealObserver.observe(el);
    });

    // 3. Counter Animation
    const counters = document.querySelectorAll('[data-count-to]');
    counters.forEach(counter => {
        if (counter.dataset.counted === "true") return;
        const target = +counter.getAttribute('data-count-to');
        const suffix = counter.getAttribute('data-suffix') || '';

        const counterObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    counter.dataset.counted = "true";
                    let count = 0;
                    const speed = target / 40;
                    const updateCount = () => {
                        count += speed;
                        if (count < target) {
                            counter.innerText = Math.floor(count).toLocaleString() + suffix;
                            setTimeout(updateCount, 25);
                        } else {
                            counter.innerText = target.toLocaleString() + suffix;
                        }
                    };
                    updateCount();
                    counterObserver.unobserve(entry.target);
                }
            });
        });
        counterObserver.observe(counter);
    });
}

// Expose globally for Blazor
window.initPublicPageScript = initPublicPageScript;