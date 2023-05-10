import anime from "animejs";

export function anim(index) {
  var spans = document.querySelectorAll('.background-span')
  spans.forEach(span => {
    span.style.backgroundColor = '#fff'
  })
  anime({
    targets: ".background-span",
    scale: 0.95,
    background: '#fff',
    duration: 20,
    delay: anime.stagger(20, { grid: [18, 9], from: index }),
    endDelay: 50,
    direction: 'alternate',
    easing: 'easeInQuad'
  })
}